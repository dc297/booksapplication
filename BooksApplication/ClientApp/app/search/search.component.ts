import { Component, OnInit } from '@angular/core';
import { SearchService } from '../search.service';
import { SearchResults } from './SearchResults';
import { Suggestions } from './Suggestions';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchResults: SearchResults;
  query: string;
  suggestions: Suggestions[];

  constructor(private searchService : SearchService) { }

  ngOnInit() {
  }

  search() : void{
    this.searchService.search(this.query).subscribe(
      searchResults => this.searchResults = searchResults
    );
  }

  autocomplete() : void{
    this.suggestions = [];
    if(this.query!="" && this.query!=undefined)
      this
        .searchService
          .autocomplete(this.query)
            .subscribe(
              suggestions =>
                this.suggestions = suggestions
            );
  }

  suggestionClick(suggestion: Suggestions) : void{
    this.query = suggestion.name;
  }

}
