import {
  Component,
  OnInit,
  inject,
  PLATFORM_ID,
  signal
} from '@angular/core';

import {
  CommonModule,
  isPlatformBrowser
} from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { ProductService } from '../../services/product-service';
import { Product } from '../../models/Product';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products implements OnInit {

  products: Product[] = [];
  filteredProducts: Product[] = [];

  // =========================
  // Search fields
  // =========================

  codeSearch = '';
  nameSearch = '';
  brandSearch = '';
  categorySearch = '';
  priceSearch = '';
  stockSearch = '';
  statusSearch = '';

  // =========================
  // Details
  // =========================

  selectedProduct: Product | null = null;

  // =========================
  // State
  // =========================

  isLoading = signal(false);
  errorMessage = '';

  // =========================
  // Pagination
  // =========================

  currentPage = 1;
  pageSize = 20;
  pageCount = 0;
  totalResults = 0;

  private platformId = inject(PLATFORM_ID);

  constructor(
    private productService: ProductService
  ) {}

  // =========================
  // Init
  // =========================

  ngOnInit(): void {

    if (isPlatformBrowser(this.platformId)) {
      this.loadProducts(1);
    }

  }

  // =========================
  // Load Products
  // =========================

  loadProducts(page: number = 1): void {

    this.isLoading.update(() => true);
    this.errorMessage = '';

    this.productService
      .getProducts(page, this.pageSize)
      .subscribe({

        next: (response) => {

          console.log('Products Response:', response);

          this.products = response.items ?? [];

          this.filteredProducts = [...this.products];

          this.currentPage = response.page;

          this.pageCount = response.pageCount;

          this.totalResults = response.totalResults;

          this.isLoading.update(() => false);
        },

        error: (error) => {

          console.error(
            'Error loading products:',
            error
          );

          this.errorMessage =
            'حصل خطأ أثناء تحميل المنتجات';

          this.isLoading.update(() => false);
        }

      });
  }

  // =========================
  // Pagination
  // =========================

  goToPage(page: number): void {

    if (
      page < 1 ||
      page > this.pageCount ||
      page === this.currentPage
    ) {
      return;
    }

    this.loadProducts(page);
  }

  nextPage(): void {

    if (this.currentPage < this.pageCount) {

      this.loadProducts(
        this.currentPage + 1
      );
    }
  }

  previousPage(): void {

    if (this.currentPage > 1) {

      this.loadProducts(
        this.currentPage - 1
      );
    }
  }

  // =========================
  // Search / Filter
  // =========================

  filterProducts(): void {

    const code =
      this.codeSearch.trim().toLowerCase();

    const name =
      this.nameSearch.trim().toLowerCase();

    const brand =
      this.brandSearch.trim().toLowerCase();

    const category =
      this.categorySearch.trim().toLowerCase();

    const price =
      this.priceSearch.trim().toLowerCase();

    const stock =
      this.stockSearch.trim().toLowerCase();

    const status =
      this.statusSearch.trim().toLowerCase();

    this.filteredProducts =
      this.products.filter(product => {

        // =========================
        // Code
        // =========================

        const matchesCode =
          !code ||
          (product.productCode ?? '')
            .toLowerCase()
            .includes(code);

        // =========================
        // Name
        // =========================

        const matchesName =
          !name ||
          (product.name ?? '')
            .toLowerCase()
            .includes(name);

        // =========================
        // Brand
        // =========================

        const matchesBrand =
          !brand ||
          (product.brand ?? '')
            .toLowerCase()
            .includes(brand);

        // =========================
        // Category
        // =========================

        const matchesCategory =
          !category ||
          (product.category ?? '')
            .toLowerCase()
            .includes(category);

        // =========================
        // Price
        // =========================

        const productPrice =
          product.unitPrice ?? 0;

        const matchesPrice =
          !price ||
          productPrice
            .toString()
            .includes(price);

        // =========================
        // Stock
        // =========================

        const productStock =
          product.stockBalance ?? 0;

        const matchesStock =
          !stock ||
          productStock
            .toString()
            .includes(stock);

        // =========================
        // Status
        // =========================

        const productStatus =
          this.getProductStatus(product);

        const matchesStatus =
          !status ||
          productStatus
            .toLowerCase()
            .includes(status);

        return (
          matchesCode &&
          matchesName &&
          matchesBrand &&
          matchesCategory &&
          matchesPrice &&
          matchesStock &&
          matchesStatus
        );

      });
  }

  // =========================
  // Product Status
  // =========================

  getProductStatus(product: Product): string {

    if (
      product.deactivate === '1' ||
      product.status === '0'
    ) {
      return 'موقوف';
    }

    return 'نشط';
  }

  isProductActive(product: Product): boolean {

    return this.getProductStatus(product) === 'نشط';
  }

  // =========================
  // Product Details
  // =========================

  showProductDetails(product: Product): void {

    this.selectedProduct = product;

  }

  closeProductDetails(): void {

    this.selectedProduct = null;

  }

  // =========================
  // Clear Filters
  // =========================

  clearFilters(): void {

    this.codeSearch = '';
    this.nameSearch = '';
    this.brandSearch = '';
    this.categorySearch = '';
    this.priceSearch = '';
    this.stockSearch = '';
    this.statusSearch = '';

    this.filteredProducts = [
      ...this.products
    ];
  }

}