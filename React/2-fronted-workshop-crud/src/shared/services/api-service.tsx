import {Session} from '../models/session.model'

const token = 'AccessToken';

class ApiService {
    getSessions() {
        return fetch("http://localhost:5000/sessions", { method: "GET" })
            .then(res => res.json());
    }

    getSessionById(id: number) {
        return fetch(`http://localhost:5000/sessions/${id}`, { method: "GET" })
            .then(res => res.json());
    }

    editSessionById(id: number, newSession: Session) {
        return fetch(`http://localhost:5000/sessions/${id}`, {
            method: "PUT",
            headers: {
                'Content-Type': 'application/json',
                'access-token': token
            },
            body: JSON.stringify({ ...newSession })
        })
            .then(res => res.json());
    }

    postSession(session: Session) {
        return fetch(`http://localhost:5000/sessions/add`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'access-token': token
            },
            body: JSON.stringify({ ...session })
        })
            .then(res => res.json());
    }

    deleteSession(id: number) {
        return fetch(`http://localhost:5000/sessions/${id}`, {
            method: "DELETE",
            headers: { 'access-token': token }
        })
            .then(res => res.json());
    }
}

export default new ApiService();