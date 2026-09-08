import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Brand } from '../models/Brand';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
     private readonly baseUrl = `${environment.apiUrl}/brands`;

  constructor(private http: HttpClient) {}

  getBrands(page: number = 1): Observable<PagedResult<Brand>> {
    const params = new HttpParams().set('page', page.toString());
    return this.http.get<PagedResult<Brand>>(this.baseUrl, { params });
  }

  getBrandById(id: number): Observable<Brand> {
    return this.http.get<Brand>(`${this.baseUrl}/${id}`);
  }
}
