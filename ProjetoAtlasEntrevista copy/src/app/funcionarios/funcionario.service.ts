import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Funcionario } from '../models/Funcionario';

@Injectable({
  providedIn: 'root'
})

export class FuncionarioService {

  urlBase = `${environment.urlBase}/api/funcionario`;

  constructor(private http : HttpClient) { }

  getAll(): Observable<Funcionario[]>{
    return this.http.get<Funcionario[]>(`${this.urlBase}`);
  }

  getStringNome(id: number): Observable<Funcionario>{
    return this.http.get<Funcionario>(`${this.urlBase}/${id}`);
  }

  post(funcionario: Funcionario) {
    return this.http.post(`${this.urlBase}`, funcionario);
  }

  put(funcionario: Funcionario){
    return this.http.put(`${this.urlBase}/${funcionario.id}`, funcionario);
  }

  delete(id: number){
    return this.http.delete(`${this.urlBase}/${id}`);
  }

  getMesDropDownvalues() : Observable <any> {
    return this.http.get<"selecionaMes">(`${this.urlBase}`);
  }
}
