﻿using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using OctoPatch.Server;

namespace OctoPatch.DesktopClient.ViewModels
{
    public sealed class RuntimeViewModel
    {
        private readonly IRuntime _runtime;

        public ObservableCollection<NodeDescription> NodeDescriptions { get; }

        public ObservableCollection<NodeInstance> Nodes { get; }

        public ObservableCollection<WireInstance> Wires { get; }

        public RuntimeViewModel()
        {
            NodeDescriptions = new ObservableCollection<NodeDescription>();
            Nodes = new ObservableCollection<NodeInstance>();
            Wires = new ObservableCollection<WireInstance>();

            var repository = new Repository();
            _runtime = new Runtime(repository);

            _runtime.OnNodeAdded += RuntimeOnOnNodeAdded;
            _runtime.OnNodeRemoved += RuntimeOnOnNodeRemoved;
            _runtime.OnWireAdded += RuntimeOnOnWireAdded;
            _runtime.OnWireRemoved += RuntimeOnOnWireRemoved;

            Task.Run(() => Setup(CancellationToken.None));
        }

        private void RuntimeOnOnWireRemoved(Guid obj)
        {
            throw new NotImplementedException();
        }

        private void RuntimeOnOnWireAdded(WireInstance obj)
        {
            throw new NotImplementedException();
        }

        private void RuntimeOnOnNodeRemoved(Guid obj)
        {
            throw new NotImplementedException();
        }

        private void RuntimeOnOnNodeAdded(NodeInstance obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Setup(CancellationToken cancellationToken)
        {
            var descriptions = await _runtime.GetNodeDescriptions(cancellationToken);
            foreach (var description in descriptions)
            {
                NodeDescriptions.Add(description);    
            }
        }
    }
}
