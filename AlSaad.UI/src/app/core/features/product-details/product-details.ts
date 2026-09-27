import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/Product';
import { ActivatedRoute,RouterModule } from '@angular/router';
import { ProductService } from '../../services/product-service';

@Component({
  selector: 'app-product-details',
  standalone :true,
  imports: [CommonModule, RouterModule],
  templateUrl: './product-details.html',
  styleUrl: './product-details.css',
})
export class ProductDetails  implements OnInit {
  product: Product | null = null;
  isLoading = true;
  errorMessage = '';
  qty = 1;
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}
 ngOnInit(): void {
     const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم المنتج غير صحيح.';
      this.isLoading = false;
      return;
    }
      this.productService.getProductById(id).subscribe({
      next: (data) => {
        this.product = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading product', err);
        this.errorMessage = 'المنتج ده مش موجود أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
   
 }

  getAvailabilityLabel(): string {
    if (!this.product) return '';

    const balance = this.product.stockBalance ?? 0;
    const threshold = this.product.lowStockThreshold ?? 0;

    if (balance <= 0) return 'غير متوفر';
    if (balance <= threshold) return 'كمية محدودة';
    return 'متوفر';
  }
   getIsLowStock(): boolean {
    return this.discountLabel !== 'متوفر';
  }

  get discountLabel(): string | null {
    if (!this.product?.discount) return null;

    return this.product.discoutType === 'percentage'
      ? `خصم ${this.product.discount}%`
      : `خصم ${this.product.discount} ج.م`;
  }
  increaseQty(): void {
    this.qty += 1;
  }

  decreaseQty(): void {
    if (this.qty > 1) {
      this.qty -= 1;
    }
  }
   addToCart(): void {
    if (!this.product) return;
    console.log('Added to cart:', this.product.name, 'x', this.qty);
  }
}


  
 

