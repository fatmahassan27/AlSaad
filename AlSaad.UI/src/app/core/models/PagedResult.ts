export interface PagedResult<T> {
  items: T[];
  page: number;
  pageCount: number;
  totalResults: number;
}