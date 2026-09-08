export interface ProductCategory {
  id: number;
  name: string;
  description?: string;
  parentId: number;
  parentCategoryName?: string;
  imageUrl?: string;
}