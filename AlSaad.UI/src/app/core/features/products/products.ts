import { Component , OnInit ,inject,PLATFORM_ID } from '@angular/core';
import { CommonModule,isPlatformBrowser  } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product-service';
import { Product } from '../../models/Product';
@Component({
  selector: 'app-products',
  standalone :true,
  imports: [CommonModule, FormsModule],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products implements OnInit{
   products: Product[] = [];
   filteredProducts: Product[] = [];
  // Search fields
  codeSearch = '';
  nameSearch = '';
  brandSearch = '';
  categorySearch = '';
  priceSearch = '';
  stockSearch = '';
  statusSearch = '';

  searchTerm = '';
  isLoading =false;
  errorMessage = '';
    private platformId = inject(PLATFORM_ID);

   constructor(private productService: ProductService) {}

  ngOnInit(): void {

    if (isPlatformBrowser(this.platformId)) {
      this.loadProducts();
    }

  }
   loadProducts(): void {
    this.isLoading = true;

    this.productService.getProducts().subscribe({
      next: (response) => {
        this.products = response.items;
        this.filteredProducts = response.items;

        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading products:', error);

        this.errorMessage = 'حصل خطأ أثناء تحميل المنتجات';
        this.isLoading = false;
      }
    });
  }
filterProducts(): void {
const code = this.codeSearch.trim().toLowerCase();
const name = this.nameSearch.trim().toLowerCase();
const brand = this.brandSearch.trim().toLowerCase();
const category = this.categorySearch.trim().toLowerCase();
const price = this.priceSearch.trim().toLowerCase();
const stock = this.stockSearch.trim().toLowerCase();
const status = this.statusSearch.trim().toLowerCase();

this.filteredProducts = this.products.filter(product => {

  const matchesCode =
    !code ||
    (product.code ?? '').toLowerCase().includes(code);

  const matchesName =
    !name ||
    (product.name ?? '').toLowerCase().includes(name);

  const matchesBrand =
    !brand ||
    (product.brand ?? '').toLowerCase().includes(brand);

  const matchesCategory =
    !category ||
    (product.category ?? '').toLowerCase().includes(category);

  const matchesPrice =
    !price ||
    product.price.toString().includes(price);

  const matchesStock =
    !stock ||
    product.stockQuantity.toString().includes(stock);

  const productStatus = product.isActive
    ? 'نشط'
    : 'موقوف';

  const matchesStatus =
    !status ||
    productStatus.toLowerCase().includes(status);

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

  clearFilters(): void {

      this.codeSearch = '';
      this.nameSearch = '';
      this.brandSearch = '';
      this.categorySearch = '';
      this.priceSearch = '';
      this.stockSearch = '';
      this.statusSearch = '';

      this.filteredProducts = this.products;

}
}
