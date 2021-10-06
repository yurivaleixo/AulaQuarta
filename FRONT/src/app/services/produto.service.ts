import { HttpClient } from '@angular/common/http';
import { listLazyRoutes } from '@angular/compiler/src/aot/lazy_routes';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto';

@Injectable({
  providedIn: "root",
})
export class ProdutoService {

  private baseUrl = "http://localhost:5000/api/produto";

  constructor(private http: HttpClient) {}

    list(): Observable<Produto[]> {
      return this.http.get<Produto[]>(`${this.baseUrl}/list`);
    }
}
