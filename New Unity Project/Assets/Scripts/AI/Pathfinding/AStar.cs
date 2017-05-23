using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
	private Node[,] nodes;

	private class Node
	{
		float X = 0, Y = 0, MovementCost = 1, G = 0;

		public Node EndNode = null;

		float H { get { return EndNode == null ? float.MaxValue : DistanceToNode(EndNode); } }
		float F { get { return G + H; } }
		private Node _parent = null;
		public Node Parent
		{
			get
			{
				return _parent;
			}

			set
			{
				_parent = value;
				if (_parent.EndNode != null)
					EndNode = _parent.EndNode;
				G = 0;
				Node node = this;
				while (node.Parent != null)
					G += DistanceToNode(node.Parent) * node.MovementCost;
			}
		}

		public Node Root
		{
			get
			{
				Node node = this;
				while (node.Parent != null) node = node.Parent;
				return node;
			}
		}

		public Node(float x, float y, float movementCost = 1)
		{
			X = x;
			Y = y;
			MovementCost = movementCost;
		}

		private float DistanceToNode(Node otherNode)
		{
			return Mathf.Sqrt(Mathf.Pow(otherNode.X - X, 2) + Mathf.Pow(otherNode.Y - Y, 2));
		}
	}
}