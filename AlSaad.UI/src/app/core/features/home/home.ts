import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Category } from '../../models/Category';
import { Product } from '../../models/Product';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  categories: Category[] = [
    { label: 'زيوت وفلاتر', path: '/products/oils-filters' },
    { label: 'فرامل', path: '/products/brakes' },
    { label: 'كهرباء وبطاريات', path: '/products/electrical' },
    { label: 'إطارات', path: '/products/tires' },
    { label: 'تعليق وشنابر', path: '/products/suspension' },
    { label: 'إكسسوارات', path: '/products/accessories' }
  ];

  featuredProducts: Product[] = [
    { name: 'طقم فحمات فرامل أمامية - كورولا', category: 'فرامل', price: 450, oldPrice: 550 },
    { name: 'فلتر زيت أصلي - هيونداي', category: 'زيوت وفلاتر', price: 120 },
    { name: 'بطارية 70 أمبير', category: 'كهرباء وبطاريات', price: 2200, oldPrice: 2500 },
    { name: 'إطار 175/65 R14', category: 'إطارات', price: 1650 },
    { name: 'طقم مساعدين أمامي - لانسر', category: 'تعليق وشنابر', price: 3200 },
    { name: 'غطاء عجلة قيادة جلد', category: 'إكسسوارات', price: 280 }
  ];
}
