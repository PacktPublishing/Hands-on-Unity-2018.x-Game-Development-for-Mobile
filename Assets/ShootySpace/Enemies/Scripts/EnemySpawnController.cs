﻿using MyCompany.GameFramework.Pooling;
using UnityEngine;

namespace MyCompany.ShootySpace.Enemies
{
	public class EnemySpawnController : MonoBehaviour
	{
		[SerializeField] private float mininumSpawnInterval = 1.0f;
		[SerializeField] private float maximumSpawnInterval = 5.0f;
		[SerializeField] private float paddingPercent = 0.2f;

		private float paddingAmount = 0.0f;
		private ObjectPool enemyPool;
		private float horizontalBounds;
		private float verticalBounds;
		private float timeSinceLastSpawn = 0.0f;
		private float nextSpawnTime;
		private Camera mainCamera;

		private void Awake()
		{
			enemyPool = new ObjectPool(Resources.Load<GameObject>("enemy"), 5);
			mainCamera = Camera.main;
			SetNextSpawnTime();
			
			SetBounds();
		}

		private void Update()
		{
			if (timeSinceLastSpawn >= nextSpawnTime)
			{
				timeSinceLastSpawn = 0.0f;
				SetNextSpawnTime();
				Spawn();
			}
			else
			{
				timeSinceLastSpawn += Time.deltaTime;
			}
		}

		private void Spawn()
		{
			Vector3 spawnLocation = GetSpawnLocation();
			enemyPool.InstantiateFromPool(spawnLocation);
		}

		private Vector3 GetSpawnLocation()
		{
			float x = Random.Range(-horizontalBounds + paddingAmount, horizontalBounds - paddingAmount);
			return new Vector3(x, 0, verticalBounds);
		}

		private void SetNextSpawnTime()
		{
			nextSpawnTime = Random.Range(mininumSpawnInterval, maximumSpawnInterval);
		}

		private void SetBounds()
		{
			verticalBounds = mainCamera.ScreenToWorldPoint(new Vector3(0, mainCamera.pixelHeight, mainCamera.transform.position.y)).z;
			horizontalBounds = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0 , mainCamera.transform.position.y)).x;
			paddingAmount = horizontalBounds * paddingPercent;
		}
	}
}
