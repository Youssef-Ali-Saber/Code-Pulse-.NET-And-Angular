import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryRequest } from '../Models/category-request.model';
import { Observable } from 'rxjs';
import { categoryResponse } from '../Models/category-response.model';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient) {}

  addCategory(category: CategoryRequest): Observable<void> {
    return this.http.post<void>(
      `${environment.apiBaseUrl}/v1/categories`,
      category
    );
  }

  getCategories(): Observable<categoryResponse[]> {
    return this.http.get<categoryResponse[]>(`${environment.apiBaseUrl}/v1/categories`);
  }

  getCategoryById(id: string): Observable<categoryResponse> {
    return this.http.get<categoryResponse>(
      `${environment.apiBaseUrl}/v1/categories/${id}`
    );
  }

  deleteCategory(id: string): Observable<void> {
    return this.http.delete<void>(
      `${environment.apiBaseUrl}/v1/categories/${id}`
    );
  }

  updateCategory(id: string, category: CategoryRequest): Observable<void> {
    return this.http.put<void>(
      `${environment.apiBaseUrl}/v1/categories/${id}`,
      category
    );
  }
}
