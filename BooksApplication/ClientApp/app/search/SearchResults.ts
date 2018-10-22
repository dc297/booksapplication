import { Book } from './Book';
export class SearchResults{
  total: number;
  page: number;
  pagesize: number;
  results: Book[];
  elapsedMilliseconds: number;
}
