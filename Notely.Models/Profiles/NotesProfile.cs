using AutoMapper;
using Notely.Repository.Entities;
using Notely.Models.Models;

namespace Notely.Models.Profiles
{
    public class NotesProfile: Profile
    {
        public NotesProfile()
        {
            CreateMap<Notes, NotesDto>();
            CreateMap<NotesDto, NotesDto>();
            CreateMap<NotesForCreationDto, Notes>();
            CreateMap<NotesForUpdateDto, Notes>();
            CreateMap<Notes, NotesForUpdateDto>();
            CreateMap<UserCreationDto, User>();
        }
    }
}