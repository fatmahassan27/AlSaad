import { Injectable, Service } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { StockTransaction } from '../models/StockTransaction';
import { PagedResult } from '../models/PagedResult';
export interface StockTransactionFilter {
  page?: number;
  limit?: number;
  productId?: number;
  storeId?: number;
  sourceType?: string;
  dateFrom?: string;
  dateTo?: string;
}
@Injectable({
  providedIn: 'root',
 })

export class StockTransactionService {
    private readonly baseUrl = `${environment.apiUrl}/stocktransactions`;

  constructor(private http: HttpClient) {}
    getStockTransactions(filter: StockTransactionFilter = {}): Observable<PagedResult<StockTransaction>> {
    let params = new HttpParams().set('page', (filter.page ?? 1).toString());

    if (filter.limit != null) params = params.set('limit', filter.limit.toString());
    if (filter.productId != null) params = params.set('productId', filter.productId.toString());
    if (filter.storeId != null) params = params.set('storeId', filter.storeId.toString());
    if (filter.sourceType) params = params.set('sourceType', filter.sourceType);
    if (filter.dateFrom) params = params.set('dateFrom', filter.dateFrom);
    if (filter.dateTo) params = params.set('dateTo', filter.dateTo);

    return this.http.get<PagedResult<StockTransaction>>(this.baseUrl, { params });
  }
    getStockTransactionById(id: number): Observable<StockTransaction> {
    return this.http.get<StockTransaction>(`${this.baseUrl}/${id}`);
  }
}
