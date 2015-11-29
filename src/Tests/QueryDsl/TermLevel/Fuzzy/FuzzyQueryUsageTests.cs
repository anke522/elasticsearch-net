using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.MockData;

namespace Tests.QueryDsl.TermLevel.Fuzzy
{
	public class FuzzyQueryUsageTests : QueryDslUsageTestsBase
	{
		public FuzzyQueryUsageTests(ReadOnlyCluster cluster, EndpointUsage usage) : base(cluster, usage) {}

		protected override object QueryJson => new
		{
			fuzzy = new
			{
				description = new
				{
					_name = "named_query",
					boost = 1.1,
					fuzziness = "AUTO",
					max_expansions = 100,
					prefix_length = 3,
					rewrite = "constant_score",
					transpositions = true,
					value = "ki"
				}
			}
		};

		protected override QueryContainer QueryInitializer => new FuzzyQuery
		{
			Name = "named_query",
			Boost = 1.1,
			Field = "description",
			Fuzziness = Fuzziness.Auto,
			Value = "ki",
			MaxExpansions = 100,
			PrefixLength = 3,
			Rewrite = RewriteMultiTerm.ConstantScore,
			Transpositions = true
		};

		protected override QueryContainer QueryFluent(QueryContainerDescriptor<Project> q) => q
			.Fuzzy(c => c
				.Name("named_query")
				.Boost(1.1)
				.Field(p => p.Description)
				.Fuzziness(Fuzziness.Auto)
				.Value("ki")
				.MaxExpansions(100)
				.PrefixLength(3)
				.Rewrite(RewriteMultiTerm.ConstantScore)
				.Transpositions()
			);
	}
}