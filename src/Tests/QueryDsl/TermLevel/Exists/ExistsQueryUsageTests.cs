using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;

namespace Tests.QueryDsl.TermLevel.Exists
{
	public class ExistsQueryUsageTests : QueryDslUsageTestsBase
	{
		public ExistsQueryUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) {}

		protected override object QueryJson => new
		{
			exists = new
			{
				_name = "named_query",
				boost = 1.1,
				field = "description"
			}
		};

		protected override QueryContainer QueryInitializer => new ExistsQuery
		{
			Name = "named_query",
			Boost = 1.1,
			Field = "description",
		};

		protected override QueryContainer QueryFluent(QueryContainerDescriptor<Project> q) => q
			.Exists(c => c
				.Name("named_query")
				.Boost(1.1)
				.Field(p => p.Description)
			);
	}
}