export interface Stores {
  id: number;
  name: string;
  shippingAddress?: string;
  isPrimary: boolean;
  activeStatus: number; // 0 = غير نشط, 1 = نشط, 2 = موقوف
  branchId: number;
}

export function getStoreStatusLabel(status: number): string {
  switch (status) {
    case 0: return 'غير نشط';
    case 1: return 'نشط';
    case 2: return 'موقوف';
    default: return 'غير معروف';
  }
}