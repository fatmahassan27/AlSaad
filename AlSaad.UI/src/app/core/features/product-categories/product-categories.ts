import { Component , OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductCategoryService } from '../../services/product-category-service';
import { ProductCategory } from '../../models/ProductCategory';

@Component({
  selector: 'app-product-categories',
  imports: [CommonModule, RouterModule],
  templateUrl: './product-categories.html',
  styleUrl: './product-categories.css',
})
export class ProductCategories  implements OnInit{
  categories: ProductCategory[] = [];
  isLoading = true;
  errorMessage = '';

  constructor(private categoryService: ProductCategoryService) {}

  ngOnInit(): void {
    this.loadCategories();
  }
  loadCategories(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.categoryService.getCategories().subscribe({
      next: (result) => {
        this.categories = result.items;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading categories', err);
        this.errorMessage = 'حصل خطأ في تحميل الكاتيجوريز، حاول تاني.';
        this.isLoading = false;
      },
    });
  }
}
