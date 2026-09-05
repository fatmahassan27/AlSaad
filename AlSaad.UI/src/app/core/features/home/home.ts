import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Category } from '../../models/Category';
import { Product } from '../../models/Product';
import { ProductService } from '../../services/product-service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit{
  categories: Category[] = [
    { label: 'زيوت وفلاتر', path: '/products/oils-filters' },
    { label: 'فرامل', path: '/products/brakes' },
    { label: 'كهرباء وبطاريات', path: '/products/electrical' },
    { label: 'إطارات', path: '/products/tires' },
    { label: 'تعليق وشنابر', path: '/products/suspension' },
    { label: 'إكسسوارات', path: '/products/accessories' }
  ];
  featuredProducts: Product[] = [];
  constructor(private productService: ProductService) {}

  ngOnInit() {
  this.productService.getProducts().subscribe({
    next: (response) => {
        console.log('RESPONSE:', response);
      console.log('ITEMS:', response.items);
      this.featuredProducts = response.items;
    },
    error: (error) => {
      console.error(error);
    }
  });
}
}
