export interface Category {
  label: string;
  path: string;
  children?: SubCategory[];
}
export interface SubCategory {
  label: string;
  path: string;
}