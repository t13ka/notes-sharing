namespace Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using Core;

    using Web.Dto.Response;

    public static class Map
    {
        static Map()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<NoteRepositoryItem, NewNoteResponseDto>());
        }

        public static NewNoteResponseDto ToDto(this NoteRepositoryItem item)
        {
            var dto = Mapper.Map<NoteRepositoryItem, NewNoteResponseDto>(item);
            return dto;
        }

        public static IEnumerable<NewNoteResponseDto> ToDto(this IEnumerable<NoteRepositoryItem> items)
        {
            var dto = Mapper.Map<IEnumerable<NoteRepositoryItem>, IEnumerable<NewNoteResponseDto>>(items);
            return dto;
        }
    }
}