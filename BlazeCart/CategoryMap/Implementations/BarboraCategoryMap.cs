﻿using System.Linq;
using Models;
using Common;
using Microsoft.Extensions.Logging;

namespace CategoryMap.Implementations
{
	public class BarboraCategoryMap : ACategoryMap, ICategoryMap
	{
		public BarboraCategoryMap(ILogger log) : base(log) { }

        public void Map(List<Category> root_cat, IDictionary<string, Category> into)
        {
            // NOTE: '.*' will match anything
            this.addMapper("Pieno gėrimai", new() { ("(?i).*", into["Pieno gėrimai"]) });
            this.addForUnmapped(into["UNMAPPED"]);

            var items = root_cat
                .GetWithoutChildren()
                .ToList();

            this.executeMapper(items);
        }

    }
}

