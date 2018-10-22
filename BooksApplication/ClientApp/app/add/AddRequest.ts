import { Book } from "./Book";
export class AddRequest{
  id: number;
  name: string;
  books: Book[];

  constructor(){
    this.name = "";
    this.books = [{id: 0,"name":"", "description":"", "coverId":""}];
  }
}
