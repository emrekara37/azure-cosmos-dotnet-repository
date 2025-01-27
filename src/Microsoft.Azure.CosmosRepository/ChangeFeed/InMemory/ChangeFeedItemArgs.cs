// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.CosmosRepository.ChangeFeed.InMemory
{
    internal class ChangeFeedItemArgs<TItem> where TItem : IItem
    {
        public IEnumerable<TItem> ItemChanges { get; private set; }

        public ChangeFeedItemArgs(IEnumerable<TItem> itemChanges) =>
            ItemChanges = itemChanges;

        public ChangeFeedItemArgs(TItem item) =>
            ItemChanges = new[] { item };
    }
}