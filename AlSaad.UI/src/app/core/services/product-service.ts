import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/Product';
import {PagedResult} from '../models/PagedResult';
@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly baseUrl = `${environment.apiUrl}/products`;
  constructor(private http: HttpClient) {}
   getProducts(page: number = 1, limit: number = 20): Observable<PagedResult<Product>> {
    return this.http.get<PagedResult<Product>>(this.baseUrl, {
      params: { page: page.toString(), limit: limit.toString() },
    });
  }
  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/${id}`);
  }
}
