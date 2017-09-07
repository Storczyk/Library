using Library.Application.General;
using Library.Infrastructure.Data;
using System.Collections.Generic;

namespace Library.Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<UserQuery>>
    {
        private readonly IUserRepository userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserQuery> Handle(GetAllUsersQuery query)
        {
            return userRepository.GetAllUsers();
        }
    }
}
