import { Injectable, Service } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Requisition } from '../../core/models/RequisitionItem';
import { PagedResult } from '../models/PagedResult';
@Injectable({
  providedIn: 'root',
 })
export class RequisitionService {
      private readonly baseUrl = `${environment.apiUrl}/requisitions`;
  constructor(private http: HttpClient) {}
  getRequisitions(page: number = 1, storeId?: number): Observable<PagedResult<Requisition>> {
    let params = new HttpParams().set('page', page.toString());
    if (storeId != null) {
      params = params.set('storeId', storeId.toString());
    }

    return this.http.get<PagedResult<Requisition>>(this.baseUrl, { params });
  }
    getRequisitionById(id: number): Observable<Requisition> {
    return this.http.get<Requisition>(`${this.baseUrl}/${id}`);
  }
}
