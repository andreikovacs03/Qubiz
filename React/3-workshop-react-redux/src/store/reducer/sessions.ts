import { IncrementVote, DecrementVote, ResetVote, MostVoted } from "../actions/types/sessions";

const initialState = {
  sessions: [{ id: 0, title: "Introduction to Ionic", speaker: "CHRISTOPHE COENRAETS", time: "9:40am", room: "Ballroom A", description: "In this session, you'll learn how to build a native-like mobile application using the Ionic Framework, AngularJS, and Cordova.", vote: 0, isMostVoted: false },
  { id: 1, title: "ReactJS in 50 Minutes", speaker: "LISA SMITH", time: "10:10am", room: "Ballroom B", description: "In this session, you'll learn everything you need to know to start building next-gen JavaScript applications using AngularJS.", vote: 0, isMostVoted: false },
  { id: 2, title: "Contributing to Apache Cordova", speaker: "JOHN SMITH", time: "11:10am", room: "Ballroom A", description: "In this session, John will tell you all you need to know to start contributing to Apache Cordova and become an Open Source Rock Star.", vote: 0, isMostVoted: false },
  { id: 3, title: "Mobile Performance Techniques", speaker: "JESSICA WONG", time: "3:10Pm", room: "Ballroom B", description: "In this session, you will learn performance techniques to speed up your mobile application.", vote: 0, isMostVoted: false },
  { id: 4, title: "Building Modular Applications", speaker: "LAURA TAYLOR", time: "2:00pm", room: "Ballroom A", description: "Join Laura to learn different approaches to build modular JavaScript applications.", vote: 0, isMostVoted: false },
  { id: 5, title: "Building React Native Applications", speaker: "Giovanni Antonaccio", time: "2:00pm", room: "Ballroom D", description: "Join Giovanni Antonaccio to learn different approaches to build modular React Native applications.", vote: 0, isMostVoted: false }],
  totalVotes: 0,
};

// eslint-disable-next-line import/no-anonymous-default-export
export default (state = initialState, { type, payload }) => {
  switch (type) {
    case IncrementVote:
      return {
        ...state,
        sessions: state.sessions.map(s => {
          if (s.id === payload) {
            s.vote = s.vote + 1;
          }
          return s;
        }),
        totalVotes: state.totalVotes + 1
      };

    case DecrementVote:
      return {
        ...state,
        sessions: state.sessions.map(s => {
          if (s.id === payload) {
            if (s.vote > 0) {
              s.vote = s.vote - 1;
            }
          }
          return s;
        }),
        totalVotes: state.totalVotes > 0 ? state.totalVotes - 1 : state.totalVotes
      };

    case ResetVote:
      return {
        ...state,
        sessions: state.sessions.map(s => {
          s.vote = 0;
          s.isMostVoted = false;
          return s;
        }),
        totalVotes: 0
      };

    case MostVoted:
      let maxVote = 0;
      state.sessions.forEach(session => {
        if (session.vote > maxVote) {
          maxVote = session.vote;
        }
      });

      return {
        ...state,
        sessions: state.sessions.map(s => {
          s.isMostVoted = s.vote > 0 && maxVote > 0 && s.vote === maxVote;
          return s;
        }),
      };
    default:
      return state
  }
}
