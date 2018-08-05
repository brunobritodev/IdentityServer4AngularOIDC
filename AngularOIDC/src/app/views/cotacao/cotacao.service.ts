import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '../../../../node_modules/@angular/common/http';
import { Observable } from '../../../../node_modules/rxjs';
import { environment } from '../../../environments/environment';
import { OAuthService } from '../../../../node_modules/angular-oauth2-oidc';
import { Moedas } from '../../shared/models/moedas.model';

@Injectable({
  providedIn: 'root'
})
export class CotacaoService {

  private defaultHeader: HttpHeaders;
  constructor(private http: HttpClient, private oauth: OAuthService) {
    this.defaultHeader = new HttpHeaders().set('Accept', 'application/json').set('Authorization', 'Bearer ' + this.oauth.getAccessToken());
   }

  public obterCotacoes(): Observable<Moedas[]> {
    const url = "cotacao/criptoMoedas";
    
    return this.http.get<Moedas[]>(environment.API_URL + url,{ headers: this.defaultHeader });
  }
}