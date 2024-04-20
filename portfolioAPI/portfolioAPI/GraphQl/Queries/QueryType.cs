using HotChocolate.Types;
using portfolioAPI.GraphQl.Types;

namespace portfolioAPI.GraphQl.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetBlogEntries())
                .Type<ListType<ObjectType<Blog>>>();
        }
    }
}