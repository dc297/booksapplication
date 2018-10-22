import { Component, OnInit } from '@angular/core';
import {AuthorService} from '../author.service';
import { Author } from './author';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  authors: Author[];
  constructor(private authorService : AuthorService) { }

  ngOnInit() {
    this.getAuthors();
  }

  getAuthors() : void{
    this.authorService.getAuthors().subscribe(authors => this.authors = authors);
  }
}
