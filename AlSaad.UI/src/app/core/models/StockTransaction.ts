export interface StockTransaction {
  id: number;
  productId: number;
  storeId: number;
  orderId?: number;
  sourceType: number;
  transactionType: number; // 1 = إدخال, 2 = إخراج
  quantity: number;
  price?: number;
  purchasePrice?: number;
  totalPrice?: number;
  currencyCode?: string;
  receivedDate?: string;
  status: number;
  notes?: string;
}

export function getTransactionTypeLabel(type: number): string {
  return type === 1 ? 'إدخال' : type === 2 ? 'إخراج' : 'غير معروف';
}

export function getSourceTypeLabel(source: number): string {
  const map: Record<number, string> = {
    1: 'تعديل يدوي',
    2: 'فاتورة',
    3: 'أمر شراء',
    4: 'إشعار دائن',
    5: 'تحويل',
    6: 'إيصال استرجاع',
    7: 'مرتجع مشتريات',
    8: 'باقة (Bundle)',
    9: 'أمر مخزون',
    14: 'إشعار خصم مشتريات',
  };
  return map[source] ?? 'غير معروف';
}

export function getStockTransactionStatusLabel(status: number): string {
  switch (status) {
    case 1: return 'مسودة';
    case 2: return 'قيد الانتظار';
    case 4: return 'تمت المعالجة';
    case 5: return 'تحويل';
    default: return 'غير معروف';
  }
}