import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UnitTemplate } from '../../core/models/UnitFactor';
import { PagedResult } from '../models/PagedResult';

@Injectable({
  providedIn: 'root',
})
export class UnitTemplateService {

 private readonly baseUrl = `${environment.apiUrl}/unittemplates`;

  constructor(private http: HttpClient) {}

  getUnitTemplates(page: number = 1): Observable<PagedResult<UnitTemplate>> {
    const params = new HttpParams().set('page', page.toString());
    return this.http.get<PagedResult<UnitTemplate>>(this.baseUrl, { params });
  }

  getUnitTemplateById(id: number): Observable<UnitTemplate> {
    return this.http.get<UnitTemplate>(`${this.baseUrl}/${id}`);
  }
    
}
