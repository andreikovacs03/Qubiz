import SessionCard from 'pages/sessions/session-card';
import * as React from 'react';
import { Session } from 'shared/models/session.model';
import ApiService from 'shared/services/api-service';

type Props = {
    match: {
        params: {
            sessionId: number
        }
    }
}

type State = {
    session: Session
}

class SessionPage extends React.Component<Props, State>{

    state: State = {
        session: { id: 0, votes: 0, title: "", speaker: "", time: "", room: "", description: "" }
    }
    updateSession() {
        ApiService.getSessionById(this.props.match.params.sessionId)
            .then((session: Session) => {
                this.setState({ session: session });
            })
    }

    handleDelete(id: number) {
        ApiService.deleteSession(id)
            .then(() => this.updateSession());
    }

    componentDidMount() {
        this.updateSession();
    }

    handleSubmit() {
        ApiService.editSessionById(this.state.session.id, this.state.session)
            .then(() => this.updateSession())
    }

    handleVote() {
        ApiService.editSessionById(this.state.session.id, { ...this.state.session, votes: this.state.session.votes + 1 })
            .then(() => this.updateSession())
    }

    render() {
        return (
            <div>
                <div>Session {this.state.session.id}</div>
                <SessionCard
                    key={this.state.session.id}
                    session={this.state.session}
                    onVote={() => this.handleVote()}
                    onDelete={(id: number) => this.handleDelete(id)}
                    onSubmit={() => this.updateSession()}
                ></SessionCard>
            </div>

        );
    }

}

export default SessionPage