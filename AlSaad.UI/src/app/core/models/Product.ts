 import { ProductCategory } from '../models/ProductCategory';
  import { ProductStock } from '../models/productStock';
 import { ProductImage } from '../models/ProductImage';
 import { ProductImageS3 } from '../models/ProductImageS3';

export interface Product {
    id: number;

  siteId?: string | null;
  staffId?: string | null;

  name?: string | null;
  description?: string | null;

  unitPrice?: number | null;
  defaultQuantity?: number | null;

  tax1?: number | null;
  tax2?: number | null;

  purchasingTax1?: number | null;
  purchasingTax2?: number | null;

  supplierId?: string | null;

  brand?: string | null;
  brandId?: string | null;

  category?: string | null;
  tags?: string | null;

  buyPrice?: number | null;

  productCode?: string | null;
  supplierCode?: string | null;

  trackStock?: string | null;
  trackingType?: string | null;

  stockBalance?: number | null;
  lowStockThreshold?: number | null;

  barcode?: string | null;
  notes?: string | null;

  deactivate?: string | null;
  status?: string | null;

  created?: string | null;
  modified?: string | null;

  followUpStatus?: string | null;

  updatedPrice?: string | null;
  averagePrice?: number | null;

  type?: string | null;

  rawStoreId?: string | null;

  class?: string | null;
  extraDetails?: string | null;

  minimumPrice?: number | null;
  profitMargin?: number | null;

  discount?: number | null;
  discoutType?: string | null;

  durationMinutes?: number | null;

  availabeOnline?: string | null;

  sourceType?: string | null;
  sourceId?: string | null;

  branchId?: string | null;

  isFeatured?: string | null;

  bundleType?: string | null;
  itemGroupId?: string | null;

  displayOrder?: number | null;

  productStoreBalance?: number | null;

  bundleFinalCost?: number | null;

  productPendingQTY?: any[] | null;

  productAvailableQTY?: {
    [key: string]: number;
  } | null;

   productCategory?: ProductCategory[] | null;

   productStock?: ProductStock[] | null;

   productImage?: ProductImage[] | null;

   productImageS3?: ProductImageS3[] | null;
}
