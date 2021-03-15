import React from 'react';
import SessionCard from './session-card';
import './app.css';
import { Typography } from '@material-ui/core';
import { connect } from "react-redux";
import Button from '@material-ui/core/Button';
import { resetVote, mostVoted } from "../store/actions/sessions";


const mapStateToProps = state => {
  return {
    sessions: state.sessions.sessions,
    totalVotes: state.sessions.totalVotes,
    mostVotedSession: state.sessions.mostVotedSession
  };
};

const App = (props) => {

  const sessionsList = props.sessions.map((session, i) => {
    return <SessionCard key={i} session={Object.assign({}, session)}></SessionCard>;
  });

  return (
    <div>
      <div className="header">
        <Typography variant="subtitle1" gutterBottom>
          Number of votes: {props.totalVotes}
          <Button variant="contained" color="secondary" className="reset-button" size="small" onClick={() => props.resetVote()}>RESET VOTES</Button>
          <Button variant="contained" color="primary" className="reset-button" size="small" onClick={() => props.mostVoted()}>SHOW MOST VOTED SESSION</Button>
        </Typography>
      </div>
      <div>
        {sessionsList}
      </div>
      {/* {props.mostVotedSession && <div>Most voted session<SessionCard session={props.mostVotedSession}></SessionCard></div>} */}
    </div>
  );
}

export default connect(mapStateToProps, { resetVote, mostVoted })(App)