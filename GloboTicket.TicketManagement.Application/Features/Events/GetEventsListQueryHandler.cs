using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events;

public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IMapper mapper;
    private readonly IAsyncRepository<Event> eventRepository;

    public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
        this.mapper = mapper;
        this.eventRepository = eventRepository;
    }

    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await eventRepository.ListAllAsync())
            .OrderBy(x => x.Date);
        return mapper.Map<List<EventListVm>>(allEvents);
    }
}
