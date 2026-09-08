import { Service  , Injectable} from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Stores } from '../models/Stores';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
 })
 export class StoreService {
    private readonly baseUrl = `${environment.apiUrl}/stores`;

  constructor(private http: HttpClient) {}

  getStores(page: number = 1, limit: number = 20): Observable<PagedResult<Stores>> {
    const params = new HttpParams()
      .set('page', page.toString())
      .set('limit', limit.toString());

    return this.http.get<PagedResult<Stores>>(this.baseUrl, { params });
  }

  getStoreById(id: number): Observable<Stores> {
    return this.http.get<Stores>(`${this.baseUrl}/${id}`);
  }

 }
