using AutoMapper;
using Pickup.Application.Features.Documents.Commands.AddEdit;
using Pickup.Domain.Entities;

namespace Pickup.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
        }
    }
}