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
