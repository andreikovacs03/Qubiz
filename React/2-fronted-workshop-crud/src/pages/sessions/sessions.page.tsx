import * as React from 'react';
import { Session } from 'shared/models/session.model';
import ApiService from 'shared/services/api-service';
import SessionCard from './session-card';
import { ButtonGroup, Typography } from '@material-ui/core';

import './sessions.page.css';
import AddForm from './session-add-form';

type Props = {};

type State = {
    sessions: Array<Session>,
    totalVotes: number
}

class SessionsPage extends React.Component<Props, State>{

    state: State = {
        sessions: [],
        totalVotes: 0
    }

    updateSessions() {
        ApiService.getSessions()
            .then((sessions: Array<Session>) =>
                this.setState({
                    sessions: sessions,
                    totalVotes: sessions.reduce((accumulator, currentValue) => accumulator + currentValue['votes'], 0)
                }))
    }

    componentDidMount() {
        this.updateSessions();
    }

    addSession(session: Session) {
        //ApiService.postSession(session).then((newSession) => this.setState({ sessions: [...this.state.sessions, newSession] }))
        ApiService.postSession(session).then(() => this.updateSessions());
    }

    deleteSession(id: number) {
        ApiService.deleteSession(id).then(() => this.updateSessions());
    }

    handleSubmit(session: Session) {
        ApiService.editSessionById(session.id, session)
            .then(() => this.updateSessions())
    }

    handleVote(session: Session) {
        ApiService.editSessionById(session.id, { ...session, votes: session.votes + 1 })
            .then(() => this.updateSessions())
        this.setState({ totalVotes: this.state.totalVotes + 1 })
    }

    render() {
        return <div>
            <div className="header">
                <Typography variant="subtitle1" gutterBottom>
                    Number of votes: {this.state.totalVotes}
                </Typography>
                <ButtonGroup>
                    <AddForm onSubmit={(newSession) => this.addSession(newSession)} color="primary" size="small">Add new session</AddForm>
                    {/* <Button color="secondary" size="small" onClick={() => this.deleteSession(this.state.sessions[this.state.sessions.length - 1].id)} className="btn delete-session">Delete last session</Button > */}
                </ButtonGroup>
            </div>
            <div className="sessions-container">
                {this.state.sessions.map((session) =>
                    <SessionCard
                        key={session.id}
                        session={session}
                        onVote={() => this.handleVote(session)}
                        onDelete={(id) => this.deleteSession(id)}
                        onSubmit={(newSession) => this.handleSubmit(newSession)}
                    ></SessionCard>)}
            </div>
        </div>
    }
}

export default SessionsPage