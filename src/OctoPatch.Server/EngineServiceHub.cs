﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OctoPatch.Server
{
    /// <summary>
    /// Common implementation of the engine service hub
    /// StreamNote: Yannick: Preise sind ok :D (2020-08-11)
    /// </summary>
    public sealed class EngineServiceHub : Hub<IRuntimeCallbacks>, IRuntimeMethods
    {
        private readonly IRepository _repository;

        private readonly IRuntimeMethods _runtime;

        public EngineServiceHub(IRepository repository, IRuntimeMethods runtime)
        {
            _repository = repository;
            _runtime = runtime;
        }

        #region Meta information

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<IEnumerable<NodeDescription>> GetNodeDescriptions(CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetNodeDescriptions());
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<IEnumerable<MessageDescription>> GetMessageDescriptions(CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetMessageDescriptions());
        }

        #endregion

        #region Engine manipulation

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<IEnumerable<NodeInstance>> GetNodes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            // return Task.FromResult(_engine.Nodes.Select(n => n.Instance));
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<IEnumerable<WireInstance>> GetWires(CancellationToken cancellationToken)
        {
            return _runtime.GetWires(cancellationToken);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<Grid> GetEngineConfiguration(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return Task.FromResult(_engine.Store());
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task SetEngineConfiguration(Grid grid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //_engine.Load(grid);
            //return Task.CompletedTask;
        }

        public Task<NodeInstance> AddNode(Guid nodeDescriptionGuid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveNode(Guid nodeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public Task<WireInstance> AddWire(Guid outputNodeId, Guid outputConnectorId, Guid inputNodeId, Guid intputConnectorId,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public Task RemoveWire(Guid wireId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #endregion

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<string> GetNodeEnvironment(Guid nodeGuid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //var node = _engine.Nodes.FirstOrDefault(n => n.Instance.Guid == nodeGuid);
            //if (node == null)
            //{
            //    throw new ArgumentException("node id does not exist");
            //}

            //// TODO: What should be returned here?
            //return Task.FromResult(string.Empty);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<string> GetNodeConfiguration(Guid nodeGuid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //var node = _engine.Nodes.FirstOrDefault(n => n.Instance.Guid == nodeGuid);
            //if (node == null)
            //{
            //    throw new ArgumentException("node id does not exist");
            //}

            //return Task.FromResult(node.Instance.Configuration);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task SetNodeConfiguration(Guid nodeGuid, string configuration, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //var node = _engine.Nodes.FirstOrDefault(n => n.Instance.Guid == nodeGuid);
            //if (node == null)
            //{
            //    throw new ArgumentException("node id does not exist");
            //}

            //return Task.CompletedTask;
            //// TODO: Apply configuration to the node
        }
    }
}
