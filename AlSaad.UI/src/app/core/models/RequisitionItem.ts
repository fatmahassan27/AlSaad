export interface RequisitionItem {
  productId?: number;
  productName?: string;
  quantity: number;
  unitPrice?: number;
}
export interface Requisition {
  id: number;
  number: string;
  date?: string;
  type: number;           // 1 = إدخال, 2 = إخراج, 3 = تحويل يدوي
  status: number;         // 1 = تحت التسليم, 3 = مقبول, 4 = مرفوض
  storeId: number;
  toStoreId?: number;
  currencyCode?: string;
  notes?: string;
  items: RequisitionItem[];
}
export function getRequisitionTypeLabel(type: number): string {
  switch (type) {
    case 1: return 'إدخال مخزون';
    case 2: return 'إخراج مخزون';
    case 3: return 'تحويل يدوي';
    default: return 'غير معروف';
  }
}
export function getRequisitionStatusLabel(status: number): string {
  switch (status) {
    case 1: return 'تحت التسليم';
    case 3: return 'مقبول';
    case 4: return 'مرفوض';
    default: return 'غير معروف';
  }
}