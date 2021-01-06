import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpHeaders } from "@angular/common/http";

import { environment } from "../../environments/environment";
import { Observable } from "rxjs";

@Injectable()
export class RoomService {
    private apiUrl = environment.apiEndpoint + `/api`;
    private headers = new HttpHeaders({ "Content-Type": "application/json" });

    constructor(private httpClient: HttpClient) { }

    createRoom(): Observable<string> {
        const url = `${this.apiUrl}/CreateRoom`;
        return this.httpClient.post(url, {}, { headers: this.headers, responseType: 'text' });
    }
}
