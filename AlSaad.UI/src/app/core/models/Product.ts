export interface Product {
  id: number;
  name: string;
  description?: string;
  price: number;
  brand?: string;
  category?: string;
  code?: string;
  barcode?: string;
  inStock: boolean;
  stockQuantity: number;
  isActive: boolean;
}
export interface PagedResult<T> {
  items: T[];
  page: number;
  pageCount: number;
  totalResults: number;
}