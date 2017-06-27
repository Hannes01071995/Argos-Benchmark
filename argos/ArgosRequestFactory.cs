using ArgosBenchmark.data.entities;
using ArgosBenchmark.data.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArgosBenchmark.argos
{
    public class ArgosRequestFactory : IRequestFactory
    {
        #region IRequestFactory
        public async Task<Tuple<string, HttpResponseMessage>> SendRequestAsync(HttpClient Client)
        {
            return await m_GetRequests[m_Random.Next(m_GetRequests.Count - 1)](Client);
        }
        #endregion

        #region ctor
        public ArgosRequestFactory(BenchmarkConfiguration Configuration, SqlImage Image)
        {
            m_Configuration = Configuration;
            m_SqlImage = Image;

            m_GetRequests.Add(GetHierarchy);
            m_GetRequests.Add(GetEntityTypeAttributes);
            m_GetRequests.Add(GetEntityTypeEntityMappings);
            m_GetRequests.Add(GetEntityChildren);
            m_GetRequests.Add(GetEntity);
            m_GetRequests.Add(GetEntityEventTypes);
            m_GetRequests.Add(GetEntityEvents);
            m_GetRequests.Add(GetEventTypes);
            m_GetRequests.Add(GetEventType);
            m_GetRequests.Add(GetEventTypeAttributes);
            m_GetRequests.Add(GetEventTypeQueries);
            m_GetRequests.Add(GetEventTypeEntityMappings);
            m_GetRequests.Add(GetEventQuery);
            m_GetRequests.Add(GetEntityMapping);
        }
        #endregion

        #region private members
        private delegate Task<Tuple<string, HttpResponseMessage>> ExecuteRequestAsync(HttpClient Client);
        private BenchmarkConfiguration m_Configuration;
        private SqlImage m_SqlImage;
        private List<ExecuteRequestAsync> m_GetRequests = new List<ExecuteRequestAsync>();
        private Random m_Random = new Random();
        #endregion

        #region private methods
        private bool RandomBool()
        {
            return m_Random.Next(1) > 0;
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetHierarchy(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entitytype/hierarchy";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityTypeAttributes(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entitytype/{m_SqlImage.RandomEntityType?.Id}/attributes";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityTypeEntityMappings(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entitytype/{m_SqlImage.RandomEntityType?.Id}/entitymappings";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityChildren(HttpClient Client)
        {
            Entity entity = m_SqlImage.RandomEntity;

            int tries = 0;
            while (entity?.Children.Count == 0)
            {
                entity = m_SqlImage.RandomEntity;

                if (tries++ >= 10)
                {
                    return null;
                }
            }

            Entity child = entity?.Children[m_Random.Next(entity.Children.Count - 1)];

            string uri = $"{m_Configuration.ApiBase}/api/entity/{entity?.Id}/children/type/{child.Type?.Id}/{child.Type?.Attributes.DefaultIfEmpty().ElementAt(0).Value}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntity(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entity/{m_SqlImage.RandomEntity?.Id}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityEventTypes(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entity/{m_SqlImage.RandomEntity?.Id}/eventtypes/{RandomBool()}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityEvents(HttpClient Client)
        {
            Entity entity = m_SqlImage.RandomEntity;

            int tries = 0;
            while (entity?.Events.Count == 0)
            {
                entity = m_SqlImage.RandomEntity;

                if (tries++ >= 10)
                {
                    return null;
                }
            }

            Event e = entity?.Events[m_Random.Next(entity.Events.Count - 1)];

            string uri = $"{m_Configuration.ApiBase}/api/entity/{entity?.Id}/eventtype/{e.Type?.Id}/event/{RandomBool()}/0/100";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventTypes(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventtypes";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventType(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventtype/{m_SqlImage.RandomEventType?.Id}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventTypeAttributes(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventtype/{m_SqlImage.RandomEventType?.Id}/attributes";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventTypeQueries(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventtype/{m_SqlImage.RandomEventType?.Id}/queries";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventTypeEntityMappings(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventtype/{m_SqlImage.RandomEventType?.Id}/entitymappings";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEventQuery(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/eventquery/{m_SqlImage.RandomQuery?.Id}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }

        private async Task<Tuple<string, HttpResponseMessage>> GetEntityMapping(HttpClient Client)
        {
            string uri = $"{m_Configuration.ApiBase}/api/entitymapping/{m_SqlImage.RandomMapping?.Id}";

            return new Tuple<string, HttpResponseMessage>(uri, await Client.GetAsync(uri).ConfigureAwait(false));
        }
        #endregion
    }
}
