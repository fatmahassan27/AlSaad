import { Injectable, Service } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ProductCategory } from '../models/ProductCategory';
import { PagedResult } from '../models/PagedResult';
@Injectable({
  providedIn: 'root',
})

export class ProductCategoryService {
    private readonly baseUrl = `${environment.apiUrl}/productcategories`;

  constructor(private http: HttpClient) {}

  getCategories(page: number = 1, limit: number = 20, parentId?: number): Observable<PagedResult<ProductCategory>> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('limit', limit.toString());

    if (parentId != null) {
      params = params.set('parentId', parentId.toString());
    }

    return this.http.get<PagedResult<ProductCategory>>(this.baseUrl, { params });
  }
    getCategoryById(id: number): Observable<ProductCategory> {
    return this.http.get<ProductCategory>(`${this.baseUrl}/${id}`);
  }
}
