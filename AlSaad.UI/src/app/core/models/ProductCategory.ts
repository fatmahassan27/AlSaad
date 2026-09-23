export interface ProductCategory {
   id?: string | null;
  name?: string | null;
  description?: string | null;

  categoryType?: string | null;
  parentId?: string | null;

  created?: string | null;
  modified?: string | null;

  image?: string | null;
  macAddress?: string | null;

  branchId?: string | null;
  status?: string | null;
}