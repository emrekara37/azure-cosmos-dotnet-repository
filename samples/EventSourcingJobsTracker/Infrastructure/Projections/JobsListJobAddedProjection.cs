// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using EventSourcingJobsTracker.Core.Events;
using EventSourcingJobsTracker.Core.ValueObjects;
using EventSourcingJobsTracker.Infrastructure.Items;
using Microsoft.Azure.CosmosEventSourcing.Projections;
using Microsoft.Azure.CosmosRepository;

namespace EventSourcingJobsTracker.Infrastructure.Projections;

public class JobsListJobAddedProjection : IDomainEventProjectionBuilder<JobAddedEvent, JobsListEventItem>
{
    private readonly IWriteOnlyRepository<JobItem> _repository;

    public JobsListJobAddedProjection(IWriteOnlyRepository<JobItem> repository) =>
        _repository = repository;

    public async ValueTask HandleAsync(
        JobAddedEvent domainEvent,
        JobsListEventItem eventSource,
        CancellationToken cancellationToken = default)
    {
        (Guid guid, string? title, DateTime due, JobListInfo? jobListInfo) = domainEvent;

        JobItem item = new(
            guid.ToString(),
            jobListInfo.Id.ToString(),
            title,
            due);

        await _repository.CreateAsync(
            item,
            cancellationToken);
    }
}