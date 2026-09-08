import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ProductCategoryService } from '../../services/product-category-service';
import { ProductCategory } from '../../models/ProductCategory';

@Component({
  selector: 'app-category-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './category-details.html',
  styleUrl: './category-details.css',
})
export class CategoryDetails implements OnInit {
    category: ProductCategory | null = null;
  isLoading = true;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private categoryService: ProductCategoryService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
     if (!id) {
      this.errorMessage = 'رقم التصنيف غير صحيح.';
      this.isLoading = false;
      return;
    }

    this.categoryService.getCategoryById(id).subscribe({
      next: (data) => {
        this.category = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading category', err);
        this.errorMessage = 'التصنيف ده مش موجود أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}

