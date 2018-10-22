using BooksApplication.data.Elastic;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.Services
{
    public class SearchService
    {
        public SearchService(ElasticClientProvider clientProvider)
        {
            this.client = clientProvider.Client;
        }

        private readonly ElasticClient client;

        public async Task<SearchResult<Book>> Search(string query, int page, int pageSize) {

            var response = await this.client.SearchAsync<Book>(searchDescriptor => searchDescriptor
                    .Query(queryContainerDescriptor => queryContainerDescriptor
                        .Bool(queryDescriptor => queryDescriptor
                            .Must(queryStringQuery => queryStringQuery
                                .QueryString(queryString => queryString
                                    .Query(query)))))
                                        .From((page - 1) * pageSize)
                                        .Size(pageSize));
            if (response != null)
                return new SearchResult<Book>
                {
                    Total = response.Total,
                    ElapsedMilliseconds = response.Took,
                    Page = page,
                    PageSize = pageSize,
                    Results = response.Documents
                };
            else return null;
        }

        public async Task<List<AutocompleteResult>> Autocomplete(string query) {
            var response = await this.client.SearchAsync<Book>(sr => sr
                .Suggest(scd => scd
                    .Completion("book-name-completion", cs => cs
                        .Prefix(query)
                        .Fuzzy(fsd => fsd
                            .Fuzziness(Fuzziness.Auto))
                        .Field(r => r.Name))));
            List<AutocompleteResult> suggestions = this.ExtractAutocompleteSuggestions(response);
            return suggestions;
        }

        private List<AutocompleteResult> ExtractAutocompleteSuggestions(ISearchResponse<Book> response)
        {
            var matchingOptions = response.Suggest["book-name-completion"].Select(s => s.Options);
            var results = matchingOptions
                .SelectMany(option => option
                .Select(opt => new AutocompleteResult() { Id = opt.Source.Id, Name = opt.Source.Name }))
                .ToList();

            return results;
        }
    }
}
