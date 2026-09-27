import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
// import { Category } from '../../models/Category';
import { Product } from '../../models/Product';
import { ProductService } from '../../services/product-service';
interface BestSeller {
  name: string;
  brand: string;
  sku: string;
  compatibility: string;
  origin: string;
  lowStock: boolean;
  oldPrice?: number;
  price: number;
  qty: number;
  icon: string;
}
 
interface Feature {
  title: string;
  desc: string;
  icon: string;
}interface Category {
  index: string;
  name: string;
  icon: string;
}
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})

export class Home {
   years = [2024, 2023, 2022, 2021, 2020, 2019];
  makes = ['Hyundai', 'Kia', 'Toyota', 'Nissan'];
  models = ['Elantra', 'Cerato', 'Sportage', 'Tucson'];
 
  // =========================
  // Categories
  // =========================
 
  categories: Category[] = [
    { index: '01', name: 'أنظمة الفرامل', icon: this.circleIcon() },
    { index: '02', name: 'المحرك ونقل الحركة', icon: this.circleIcon() },
    { index: '03', name: 'نظام التعليق', icon: this.circleIcon() },
    { index: '04', name: 'الكهرباء', icon: this.circleIcon() },
  ];
 
  constructor(private productService: ProductService) {}
bestSellers: BestSeller[] = [
    {
      name: 'دبل فرامل أمامي',
      brand: 'MOBIS',
      sku: 'KR43948GK',
      compatibility: 'Hyundai Elantra 2020-2023',
      origin: 'كوريا',
      lowStock: false,
      oldPrice: 450,
      price: 365,
      qty: 1,
      icon: this.partIcon(),
    },
    {
      name: 'فلتر زيت محرك',
      brand: 'MOBIS',
      sku: 'OF-35505',
      compatibility: 'Kia Cerato 2019-2024',
      origin: 'كوريا',
      lowStock: false,
      oldPrice: 220,
      price: 185,
      qty: 1,
      icon: this.partIcon(),
    },
    {
      name: 'بوجيه NGK',
      brand: 'NGK',
      sku: 'NGK-LZKR6B',
      compatibility: 'Hyundai / Kia',
      origin: 'اليابان',
      lowStock: true,
      oldPrice: 190,
      price: 160,
      qty: 1,
      icon: this.partIcon(),
    },
    {
      name: 'مساعد أمامي',
      brand: 'Mando',
      sku: 'SHK-54651',
      compatibility: 'Hyundai Elantra AD',
      origin: 'كوريا',
      lowStock: false,
      oldPrice: 2950,
      price: 2540,
      qty: 1,
      icon: this.partIcon(),
    },
  ];
 
  // =========================
  // Feature strip
  // =========================
 
  features: Feature[] = [
    {
      title: 'طلبات أسرع',
      desc: 'أعد طلب القطع الأساسية لحسابك بخطوة واحدة.',
      icon: this.dotIcon(),
    },
    {
      title: 'أسعار حصرية',
      desc: 'اعرض السعر المخصص لحسابك بعد تسجيل الدخول.',
      icon: this.dotIcon(),
    },
    {
      title: 'توافق أوضح',
      desc: 'حدد سيارتك للوصول إلى القطع المتوافقة فورًا.',
      icon: this.dotIcon(),
    },
    {
      title: 'قطع أصلية وموثوقة',
      desc: 'منتجات من علامات تجارية معروفة وموثوقة.',
      icon: this.dotIcon(),
    },
  ];
 
  // =========================
  // Actions
  // =========================
 
  increaseQty(part: BestSeller): void {
    part.qty += 1;
  }
 
  decreaseQty(part: BestSeller): void {
    if (part.qty > 1) {
      part.qty -= 1;
    }
  }
 
  addToCart(part: BestSeller): void {
    console.log('Added to cart:', part.name, 'x', part.qty);
  }
 
  // =========================
  // Placeholder inline icons
  // (replace with real SVG icon set later)
  // =========================
 
  private circleIcon(): string {
    return `<svg width="28" height="28" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle cx="12" cy="12" r="9" stroke="currentColor" stroke-width="1.5"/>
      <circle cx="12" cy="12" r="3" fill="currentColor"/>
    </svg>`;
  }
 
  private partIcon(): string {
    return `<svg width="20" height="20" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <rect x="5" y="5" width="14" height="14" rx="3" stroke="currentColor" stroke-width="1.5"/>
    </svg>`;
  }
 
  private dotIcon(): string {
    return `<svg width="22" height="22" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <circle cx="12" cy="12" r="4" fill="currentColor"/>
    </svg>`;
  }
 
}

