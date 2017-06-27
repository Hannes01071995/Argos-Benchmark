using ArgosBenchmark.data;
using ArgosBenchmark.data.entities;
using ArgosBenchmark.data.events;
using ArgosBenchmark.data.mappings;
using ArgosBenchmark.data.queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ArgosBenchmark
{
    public class SqlImage
    {
        #region props
        public string SqlFilePath { get; private set; }
        #endregion

        #region public methods
        public EntityType RandomEntityType
        {
            get { return SelectRandom(m_EntityTypes); }
        }

        public Entity RandomEntity
        {
            get { return SelectRandom(m_Entities); }
        }

        public EventType RandomEventType
        {
            get { return SelectRandom(m_EventTypes); }
        }

        public EventQuery RandomQuery
        {
            get { return SelectRandom(m_EventQueries); }
        }

        public EventEntityMapping RandomMapping
        {
            get { return SelectRandom(m_EventEntityMappings); }
        }
        #endregion

        #region ctor
        public SqlImage(string SqlFilePath)
        {
            if (!File.Exists(SqlFilePath) || !SqlFilePath.EndsWith(".sql"))
            {
                throw new ArgumentException("File must be of type \".sql\"");
            }

            this.SqlFilePath = SqlFilePath;
            m_EntityTypes.Add(RootType.Instance.Id, RootType.Instance);
            m_Entities.Add(Root.Instance.Id, Root.Instance);

            ReadSqlFile(SqlFilePath);
            PerformInsert();

            Console.WriteLine("SqlImage finished");
        }
        #endregion

        #region private members
        private Random m_Random = new Random();
        private Dictionary<string, List<string[]>> m_InsertBuffer = new Dictionary<string, List<string[]>>();
        private Dictionary<long, EntityType> m_EntityTypes = new Dictionary<long, EntityType>();
        private Dictionary<long, EventType> m_EventTypes = new Dictionary<long, EventType>();
        private Dictionary<long, Entity> m_Entities = new Dictionary<long, Entity>();
        private Dictionary<long, Event> m_Events = new Dictionary<long, Event>();
        private Dictionary<long, EventQuery> m_EventQueries = new Dictionary<long, EventQuery>();
        private Dictionary<long, EventEntityMapping> m_EventEntityMappings = new Dictionary<long, EventEntityMapping>();
        #endregion

        #region private methods
        private void ReadSqlFile(string SqlFilePath)
        {
            Regex regex = new Regex("^INSERT INTO `(?<Table>.*)` VALUES (?<Values>.*);$");

            foreach (string line in File.ReadAllLines(SqlFilePath))
            {
                if (!line.StartsWith("INSERT INTO"))
                {
                    continue;
                }

                Match regexResult = regex.Match(line);

                if (!regexResult.Success)
                {
                    continue;
                }

                InterpretInsertInto(regexResult);
            }
        }

        private void InterpretInsertInto(Match RegexMatch)
        {
            string table = RegexMatch.Groups["Table"].Value.ToLower();
            string values = RegexMatch.Groups["Values"].Value;

            if (values.StartsWith("("))
            {
                values = values.Remove(0, 1);
            }

            if (values.EndsWith(");"))
            {
                values = values.Remove(values.Length - 2);
            }

            if (values.EndsWith(")"))
            {
                values = values.Remove(values.Length - 1);
            }

            string[] split = values.Split(new string[] { "),(" }, StringSplitOptions.RemoveEmptyEntries);

            if (!m_InsertBuffer.ContainsKey(table))
            {
                m_InsertBuffer.Add(table, new List<string[]>());
            }

            m_InsertBuffer[table].Add(split);
        }

        private void PerformInsert()
        {
            // EntityType
            Insert("EntityType", InsertIntoEntityType);

            // EventType
            Insert("EventType", InsertIntoEventType);

            // TypeAttribute
            Insert("TypeAttribute", InsertIntoTypeAttribute);

            // Entity
            Insert("Entity", InsertIntoEntity);

            // Event
            Insert("Event", InsertIntoEvent);

            // Attributes
            Insert("Attribute", InsertIntoAttribute);

            // EventQuery
            Insert("EventQuery", InsertIntoEventQuery);

            // EventEntityMapping
            Insert("EventEntityMapping", InsertIntoEntityMapping);

            // MappingCondition
            Insert("MappingCondition", InsertIntoMappingCondition);
        }

        private void Insert(string TableName, Action<string[]> Method)
        {
            List<string[]> values;

            if (m_InsertBuffer.TryGetValue(TableName.ToLower(), out values))
            {
                foreach (string[] v in values)
                {
                    try
                    {
                        Method(v);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception while inserting: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Cannot find {TableName} in Insert Buffer.");
            }
        }

        private string[] Split(string Value)
        {
            try
            {
                Regex regex = new Regex(@"(('.*?([^\\]'))|('')|(-?\d+)),?");
                MatchCollection matches = regex.Matches(Value);

                List<string> result = new List<string>();
                foreach (Match match in matches)
                {
                    string value = match.Value;

                    if (value.EndsWith(","))
                    {
                        value = value.Remove(value.Length - 1);
                    }

                    result.Add(value);
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                return new string[0];
            }
        }

        private T SelectRandom<T>(Dictionary<long, T> Dictionary) where T: class
        {
            if (Dictionary.Count == 0)
            {
                return null;
            }

            return Dictionary.ElementAt(m_Random.Next(Dictionary.Count - 1)).Value;
        }

        private void InsertIntoEntityType(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id,Name,ParentId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 3)
                {
                    Console.WriteLine("Unknown EntityType-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                string name = splitEntry[1].Replace("'", "");
                long parentId = Convert.ToInt64(splitEntry[2]);

                EntityType newType = EntityType(id, true);
                EntityType parent = EntityType(parentId, true);

                parent.Children.Add(newType);

                newType.Parent = parent;
                newType.Name = name;
            }
        }

        private EntityType EntityType(long Id, bool Create = false)
        {
            EntityType type = null;

            if (m_EntityTypes.TryGetValue(Id, out type))
            {
                return type;
            }

            if (!Create)
            {
                return null;
            }

            type = new EntityType() { Id = Id };
            m_EntityTypes.Add(Id, type);

            return type;
        }

        private void InsertIntoEventType(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, Deletable, Name, ShouldBeRegistered, TimestampAttributeId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 5)
                {
                    Console.WriteLine("Unknown EventType-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                bool deletable = splitEntry[1] == "'\\0'" ? false : true;
                string name = splitEntry[2];
                bool shouldBeRegistered = splitEntry[3] == "'\\0'" ? false : true;
                long timestampAttributeId = Convert.ToInt64(splitEntry[4]);

                EventType type = EventType(id, true);

                type.IsDeletable = deletable;
                type.Name = name;
                type.TimestampAttributeId = timestampAttributeId;
            }
        }

        private EventType EventType(long Id, bool Create = false)
        {
            EventType type = null;

            if (m_EventTypes.TryGetValue(Id, out type))
            {
                return type;
            }

            if (!Create)
            {
                return null;
            }

            type = new EventType() { Id = Id };
            m_EventTypes.Add(Id, type);

            return type;
        }

        private IArgosType ArgosType(long Id)
        {
            if (m_EntityTypes.ContainsKey(Id))
            {
                return m_EntityTypes[Id];
            }

            if (m_EventTypes.ContainsKey(Id))
            {
                return m_EventTypes[Id];
            }

            return null;
        }

        private void InsertIntoTypeAttribute(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, Name, TypeId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 3)
                {
                    Console.WriteLine("Unknown TypeAttribute-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                string name = splitEntry[1].Replace("'", "");
                long typeId = Convert.ToInt64(splitEntry[2]);

                IArgosType type = ArgosType(typeId);
                type?.Attributes.Add(id, name);

                if (type is EventType)
                {
                    EventType eventType = type as EventType;
                    
                    if (eventType?.TimestampAttributeId == id)
                    {
                        eventType.TimestampAttribute = name;
                    }
                }
            }
        }

        private void InsertIntoEntity(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, Name, ParentId, Status, TypeId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 5)
                {
                    Console.WriteLine("Unknown Entity-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                string name = splitEntry[1];
                long parentId = Convert.ToInt64(splitEntry[2]);
                string status = splitEntry[3];
                long typeId = Convert.ToInt64(splitEntry[4]);

                Entity newEntity = Entity(id, true);
                Entity parent = Entity(parentId, true);
                EntityType type = EntityType(typeId);

                parent?.Children.Add(newEntity);
                type?.Instances.Add(newEntity);

                newEntity.Name = name;
                newEntity.Parent = parent;
                newEntity.Status = status;
                newEntity.Type = type;
            }
        }

        private Entity Entity(long Id, bool Create = false)
        {
            Entity entity;

            if (m_Entities.TryGetValue(Id, out entity))
            {
                return entity;
            }

            if (!Create)
            {
                return null;
            }

            entity = new Entity() { Id = Id };
            m_Entities.Add(Id, entity);

            return entity;
        }

        private void InsertIntoEvent(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, EntityId, TypeId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 3)
                {
                    Console.WriteLine("Unknown Event-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                long entityId = Convert.ToInt64(splitEntry[1]);
                long typeId = Convert.ToInt64(splitEntry[2]);

                Event newEvent = Event(id, true);
                Entity entity = Entity(entityId);
                EventType type = EventType(typeId);

                entity?.Events.Add(newEvent);
                type?.Instances.Add(newEvent);

                newEvent.Type = type;
                newEvent.Entity = entity;
            }
        }

        private Event Event(long Id, bool Create = false)
        {
            Event e;

            if (m_Events.TryGetValue(Id, out e))
            {
                return e;
            }

            if (!Create)
            {
                return null;
            }

            e = new Event() { Id = Id };
            m_Events.Add(Id, e);

            return e;
        }

        private IArgosInstance ArgosInstance(long Id)
        {
            if (m_Entities.ContainsKey(Id))
            {
                return m_Entities[Id];
            }

            if (m_Events.ContainsKey(Id))
            {
                return m_Events[Id];
            }

            return null;
        }

        private void InsertIntoAttribute(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, OwnerId, TypeAttributeId, Value
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 4)
                {
                    Console.WriteLine("Unknown Attribute-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                long ownerId = Convert.ToInt64(splitEntry[1]);
                long typeAttributeId = Convert.ToInt64(splitEntry[2]);
                string value = splitEntry[3];

                IArgosInstance instance = ArgosInstance(ownerId);

                if (instance?.Type?.Attributes.ContainsKey(typeAttributeId) == false)
                {
                    continue;
                }

                instance?.Attributes.Add(instance?.Type?.Attributes[typeAttributeId], value);
            }
        }

        private void InsertIntoEventQuery(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, Description, Query, TypeId, Uuid
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 5)
                {
                    Console.WriteLine("Unknown EventQuery-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                string description = splitEntry[1];
                string query = splitEntry[2];
                long typeId = Convert.ToInt64(splitEntry[3]);
                string uuid = splitEntry[4];

                EventType eventType = EventType(typeId);
                EventQuery newQuery = EventQuery(id, true);

                eventType?.Queries.Add(newQuery);

                newQuery.Description = description;
                newQuery.Query = query;
                newQuery.Type = eventType;
                newQuery.Uuid = uuid;
            }
        }

        private EventQuery EventQuery(long Id, bool Create = false)
        {
            EventQuery query;

            if (m_EventQueries.TryGetValue(Id, out query))
            {
                return query;
            }

            if (!Create)
            {
                return null;
            }

            query = new EventQuery() { Id = Id };
            m_EventQueries.Add(Id, query);

            return query;
        }

        private void InsertIntoEntityMapping(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, EntityTypeId, EventTypeId, TargetStatus
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 4)
                {
                    Console.WriteLine("Unknown EventEntityMapping-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                long entityTypeId = Convert.ToInt64(splitEntry[1]);
                long eventTypeId = Convert.ToInt64(splitEntry[2]);
                string targetStatus = splitEntry[3];

                EntityType entityType = EntityType(entityTypeId);
                EventType eventType = EventType(eventTypeId);
                EventEntityMapping newMapping = EventEntityMapping(id, true);

                entityType?.Mappings.Add(newMapping);
                eventType?.Mappings.Add(newMapping);

                newMapping.EntityType = entityType;
                newMapping.EventType = eventType;
            }
        }

        private EventEntityMapping EventEntityMapping(long Id, bool Create = false)
        {
            EventEntityMapping mapping;

            if (m_EventEntityMappings.TryGetValue(Id, out mapping))
            {
                return mapping;
            }

            if (!Create)
            {
                return null;
            }

            mapping = new EventEntityMapping() { Id = Id };
            m_EventEntityMappings.Add(Id, mapping);

            return mapping;
        }

        private void InsertIntoMappingCondition(string[] Values)
        {
            foreach (string entry in Values)
            {
                // id, EntityTypeAttributeId, EventTypeAttributeId, MappingId
                string[] splitEntry = Split(entry);

                if (splitEntry.Length != 4)
                {
                    Console.WriteLine("Unknown MappingCondition-Entry: " + entry);
                    continue;
                }

                long id = Convert.ToInt64(splitEntry[0]);
                long entityTypeAttributeId = Convert.ToInt64(splitEntry[1]);
                long eventTypeAttributeId = Convert.ToInt64(splitEntry[2]);
                long mappingId = Convert.ToInt64(splitEntry[3]);

                EventEntityMapping mapping = EventEntityMapping(mappingId);

                if (mapping?.EntityType?.Attributes.ContainsKey(entityTypeAttributeId) == false || mapping?.EventType?.Attributes.ContainsKey(eventTypeAttributeId) == false)
                {
                    continue;
                }

                mapping?.Conditions.Add(new MappingCondition() { Id = id, Mapping = mapping, EntityTypeAttributeId = entityTypeAttributeId, EventTypeAttributeId = eventTypeAttributeId });
            }
        }
        #endregion
    }
}
