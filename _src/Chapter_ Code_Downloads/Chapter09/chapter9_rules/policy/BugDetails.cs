using System;
using System.Collections.Generic;
using System.Text;

public enum BugPriority
{
  Low,
  Medium,
  High
}

public class BugDetails
{
  private string _title;
  public string Title
  {
    get { return _title; }
    set { _title = value; }
  }

  private bool _openedByClient;
  public bool IsOpenedByClient
  {
    get { return _openedByClient; }
    set { _openedByClient = value; }
  }

  private bool _isSecurityRelated;
  public bool IsSecurityRelated
  {
    get { return _isSecurityRelated; }
    set { _isSecurityRelated = value; }
  }

  private bool _isVerified;
  public bool IsVerified
  {
    get { return _isVerified; }
    set { _isVerified = value; }
  }

  private BugPriority _priority;
  public BugPriority Priority
  {
    get { return _priority; }
    set { _priority = value; }
  }


  private int _score;
  public int Score
  {
    get { return _score; }
    set { _score = value; }
  }

}
